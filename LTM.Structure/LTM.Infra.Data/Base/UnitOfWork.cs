using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using LTM.Infra.Settings;
using Microsoft.EntityFrameworkCore;

namespace LTM.Infra.Data.Base
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private DbConnection _connection;
        private DbTransaction _transaction;
        private bool _disposed;

        private ICollection<DbContext> _contexts;

        public UnitOfWork()
        {
            _connection = GetNewConnection();
            _contexts = new List<DbContext>();
        }

        public DbConnection Connection
        {
            get { return _connection; }
        }

        public DbTransaction Transaction
        {
            get { return _transaction; }
        }

        public void AddContext(DbContext context)
        {
            if (!_contexts.Contains(context))
                _contexts.Add(context);
        }

        private DbConnection GetNewConnection()
        {
            return new SqlConnection(AppSettings.ConnectionStrings.DefaultConnection);
        }

        public void BeginTransaction()
        {
            if (_connection == null)
                _connection = GetNewConnection();

            if (_connection.State == ConnectionState.Closed)
                _connection.Open();

            _transaction = _connection.BeginTransaction();

            foreach (var context in _contexts)
            {
                if (context.Database.CurrentTransaction == null)
                    context.Database.UseTransaction(_transaction);
            }
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception)
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                Close();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction.Connection != null)
                    _transaction.Rollback();
            }
            finally
            {
                Close();
            }
        }

        private void Close()
        {
            _connection.Close();

            foreach (var context in _contexts)
            {
                context.Database.CloseConnection();

                if (context.Database.CurrentTransaction != null)
                    context.Database.CurrentTransaction.Dispose();
            }
        }

        public void Dispose()
        {
            dispose(true);
            GC.SuppressFinalize(this);
        }

        private void dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_transaction != null)
                        _transaction.Dispose();

                    if (_connection != null)
                        _connection.Dispose();

                    foreach (var context in _contexts)
                        context.Dispose();

                    _contexts.Clear();
                }

                _disposed = true;
            }
        }

        ~UnitOfWork()
        {
            dispose(false);
        }
    }
}
