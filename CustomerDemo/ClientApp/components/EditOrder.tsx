import * as React from 'react';
import OrderStore from '../store/OrderStore'
import { OrderDto } from '../dto/orderDto'

type EditOrderType = "new" | "update";

interface IEditOrderProps {
    order: OrderDto;
    type: EditOrderType;
    onEdited?: () => void;
}

interface IEditOrderState {    
    Name: string;
    PhoneNo: string;
    Email: string;
    Address: string;
    ProductId: number;

    Saved: boolean;
    Failed: boolean;
    ErrorMessage?: boolean;
}

export class EditOrder extends React.Component<IEditOrderProps, IEditOrderState> {
    displayName = "NewOrder";
    constructor(props: IEditOrderProps) {
        super(props);

        var order = props.order;
        this.state = {            
            ProductId: order.orderItems[0].productId ? order.orderItems[0].productId : 0,            
            Name: order.customer ? (order.customer.name ? order.customer.name : "") : "",
            PhoneNo: order.customer ? (order.customer.phoneNo ? order.customer.phoneNo : "") : "",
            Email: order.customer ? (order.customer.email ? order.customer.email : "") : "",
            Address: order.location ? (order.location.address ? order.location.address : "") : "",
            Saved: false,
            Failed: false,
        }
    }

    onChangeProduct(event: any) {
        var value = event.currentTarget.value;
        this.setState({ ProductId: Number.parseInt(value) });
    }

    onChangeName(event: any) {
        var value = event.target.value;
        this.setState({ Name: value });
    }

    onChangePhoneNo(event: any) {
        var value = event.target.value;
        this.setState({ PhoneNo: value });
    }

    onChangeEmail(event: any) {
        var value = event.target.value;
        this.setState({ Email: value });
    }

    onChangeAddress(event: any) {
        var value = event.target.value;
        this.setState({ Address: value });
    }

    fillOrder(): OrderDto {
        var order = this.props.order;
        if (order === null)
            order = {
                orderItems: [{ orderItemId: 0, productId: this.state.ProductId }]
            }

        if (order.orderItems === null) {
            order.orderItems = [{ orderItemId: 0, productId: this.state.ProductId }]
        } else {     
             order.orderItems.push({ orderItemId: 0, productId: this.state.ProductId });
        }
        
        if (order.customer == null) {
            order.customer =
                {
                    customerId: 0,
                    name: this.state.Name,
                    phoneNo: this.state.PhoneNo,
                    email: this.state.Email
                }
        } else {
            order.customer.name = this.state.Name;
            order.customer.phoneNo = this.state.PhoneNo;
            order.customer.email = this.state.Email;
        }
        order.location ? order.location.address = this.state.Address : order.location = {
            locationId: 0,
            address: this.state.Address
        };
        order.serviceDate = new Date();

        return order;
    }

    onSave() {
        var order = this.fillOrder();        

        if (this.props.type === "new") {
            OrderStore.saveOrder(order).then(r => { });
        } else {
            order.orderId = this.props.order.orderId;
            OrderStore.updateOrder(order);
        }

        if (this.props.onEdited) {
            this.props.onEdited();
        }
    }

    public render() {
        return <div>
            New order
            <select value={this.state.ProductId}>
                <option key="0" value="Choose product"> Choose product </option>
                <option key="1" value="Moving"> Moving </option>
                <option key="2" value="Packing"> Packing </option>
                <option key="3" value="Cleaning"> Cleaning </option>
            </select>

            <div>
                <label> Name </label>
                <input type="text" value={this.state.Name} onChange={this.onChangeName.bind(this)} />
            </div>

            <div>
                <label> Phone </label>
                <input type="text" value={this.state.PhoneNo} onChange={this.onChangePhoneNo.bind(this)} />
            </div>

            <div>
                <label> Email </label>
                <input type="text" value={this.state.Email} onChange={this.onChangeEmail.bind(this)} />
            </div>

            <button onClick={this.onSave.bind(this)} > {this.props.type==="new" ? "Store order" : "Update order" } </button>
        </div>;
    }
}
