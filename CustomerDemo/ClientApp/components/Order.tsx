import * as React from 'react';
//import { Link, RouteComponentProps } from 'react-router-dom';
//import OrderStore from '../store/OrderStore'
import { OrderDto } from '../dto/orderDto'
import { EditOrder } from './EditOrder'
import { OrderItemDto } from "ClientApp/dto/orderItemDto";

interface IOrderProps {
    order: OrderDto;
}

interface IOrderState {
    order: OrderDto;
    edit: boolean;
}


export class Order extends React.Component<IOrderProps, IOrderState> {
    displayName = "Order";

    constructor(props: IOrderProps) {
        super(props);

        this.state = {
            order: props.order,
            edit: false
        }
    }

    componentWillReceiveProps(props: IOrderProps) {
        this.setState({ order: props.order })
    }

    onEditOrder() {
        this.setState({
            edit: true
        });
    }

    onEditedOrder() {
        this.setState({
            edit: false
        });
    }

    render() {
        var order = this.state.order;
        var edit: boolean = this.state.edit;

        return (
            <div>

                {
                    edit &&
                    <div className="order" >
                        <EditOrder order={order} type="update" onEdited={this.onEditedOrder.bind(this)} />
                    </div>
                }

                {
                    edit === false &&
                    <div className="order" >
                        <div className="order-item">
                            OrderId: {order.orderId}
                        </div>
                        {
                            //<div>
                            //    ServiceDate: {order.serviceDate ? order.serviceDate.toDateString() : ""}
                            //</div>
                        }
                        {
                            order.orderItems &&
                            order.orderItems.map(function (orderItem: OrderItemDto) {
                                return (
                                    <div key={orderItem.orderItemId}> ProductId: {orderItem.productId} </div>
                                )
                            }, this)
                        }

                        {
                            order.customer &&
                            <div>
                                <div className="order-item">
                                    Customer name: {order.customer.name}
                                </div>
                                <div className="order-item">
                                    Customer phone: {order.customer.phoneNo}
                                </div>
                                <div className="order-item">
                                    Customer email: {order.customer.email}
                                </div>
                            </div>
                        }
                        {
                            order.location &&
                            <div className="order-item">
                                OrderAddress: {order.location.address}
                            </div>
                        }
                        <button onClick={this.onEditOrder.bind(this)} > Edit </button>
                    </div >
                }

            </div>
        )
    }
}
