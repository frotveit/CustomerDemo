import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import OrderStore from '../store/OrderStore'
import { OrderDto } from '../dto/orderDto'
import { EditOrder } from './EditOrder'

interface INewOrderProps extends RouteComponentProps<{}> {
}

interface INewOrderState {
    Name: string;
    PhoneNo: string;
    Email: string;
    Address: string;
    ProductId: number;    
}

class NewOrder extends React.Component<INewOrderProps, INewOrderState> {
    displayName = "NewOrder";
    constructor(props: INewOrderProps) {
        super(props);

        this.state = {
            ProductId: 0,
            Name: "",
            PhoneNo: "",
            Email: "",
            Address: ""
        }
    }

    public render() {
        var emptyOrder: OrderDto = {
            orderItems: [{ orderItemId: 0, productId: 0 }],
            customer: {
                customerId: 0,
                name: "",
                phoneNo: "",
                email: "",
            },
            location: {
                locationId: 0,
                address: ""
            }
        }

        return <EditOrder order={emptyOrder} type="new" />            
    }    
}

export default NewOrder;