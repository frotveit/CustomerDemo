import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import OrderStore from '../store/OrderStore'
import { OrderDto } from '../dto/orderDto'
import { Order } from './Order'

interface IOrdersProps extends RouteComponentProps<{}> {
}

interface IOrdersState {
    Orders: OrderDto[];
}


class Orders extends React.Component<IOrdersProps, IOrdersState> {
    displayName = "Orders";

    constructor(props: IOrdersProps) {
        super(props);

        this.state = {
            Orders: []
        }

        OrderStore.orders().then(r => {
            this.setState({
                Orders: r ? r : []
            })
        })
    }       

    public render() {
        return <div> 
            <h1> Orders </h1>
            {
                this.state.Orders.map(function (order: OrderDto) {
                    return (
                        <Order order={order} />                        
                    )
                }, this)
            }
        </div>;
    }
}

export default Orders;



