using FitFlow.Models.FitFlow;
using System;
using System.Transactions;

namespace FitFlow.Extensions.DB
{
    public static class FitFlowEntitiesExtention
    {
        public static void Transform(this FitFlowEntities @this, Action<FitFlowEntities> action)
        {
            using (var dbc = new FitFlowEntities()) {
                using (var tr = new TransactionScope(TransactionScopeOption.Required,
                    new TransactionOptions { IsolationLevel = IsolationLevel.ReadCommitted })) {
                    action(dbc);
                    tr.Complete();
                }
            }
        }
    }
}