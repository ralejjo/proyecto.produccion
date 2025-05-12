using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Tenaris.Library.DbClient;
using Host.Database;
using Shared.DTO;

namespace Host
{
    internal class WorkOrder : MarshalByRefObject, IWorkOrder
    {
        private readonly DbClient db;

        private int _workOrderId;
        private DateTime _date;
        private int _lote;
        private int _colada;
        private int _clientId;
        private int _pieceId;
        private int _quantity;
        private int _processTypeId;
        private bool _isActive;
        private DateTime _startedAt;
        private DateTime _updatedAt;


        public int workOrderId { get { return _workOrderId; } }

        public DateTime date { get { return _date; } }

        public int lote { get { return _lote; } }

        public int colada { get { return _colada; } }

        public int clientId { get { return _clientId; } }

        public int pieceId { get { return _pieceId; } }

        public int quantity { get { return _quantity; } }

        public int processTypeId { get { return _processTypeId; } }

        public bool isActive { get { return _isActive; } }

        public DateTime startedAt { get { return _startedAt; } }

        public DateTime updatedAt { get { return _updatedAt; } }
        public WorkOrder()
        {
            db = Context.Instance.Db;
        }

        public int CreateWorkOrder(CreateWorkOrderDto workOrder)
        {
            var newPiece = db.Execute
                (
                    new InsPiece
                    {
                        colorid = workOrder.ColorId,
                        materialid = workOrder.MaterialId,
                        stateid = workOrder.StateId,
                        typeid = workOrder.TypeId,
                        width = workOrder.Width,
                        length = workOrder.Length,
                        thickness = workOrder.Thickness,
                    }
                );
            var newWorkOrder = db.Execute
                (
                    new InsWorkOrder
                    {
                        date = workOrder.Date,
                        lote = workOrder.Lote,
                        colada = workOrder.Colada,
                        clientid = workOrder.ClientId,
                        pieceid = newPiece.identity,
                        quantity = workOrder.Quantity,
                        processtypeid = workOrder.ProcessTypeId
                    }
                );
            var newPieceOrder = db.Execute
                (
                    new InsPieceOrder
                    {
                        workOrderId = newWorkOrder.identity,
                        pieceId = newPiece.identity
                    }
                );
            return newWorkOrder.identity;
        }

        public WorkOrderDto[] GetById(int workOrderId)
        {
            var result = db.Execute
            (
                new GetWorkOrderById
                {
                    workorderid = workOrderId
                }
            );
            return result.rows.ToArray();
        }

        public WorkOrderDto[] GetByPieceId(int pieceId)
        {
            var result = db.Execute
            (
                new GetWorkOrderByPieceId
                {
                    pieceid = pieceId
                }
            );
            return result.rows.ToArray();
        }
    }
}
