import * as React from 'react';
//import { Link, RouteComponentProps } from 'react-router-dom';
//import OrderStore from '../store/OrderStore'
import { CustomerDto } from '../dto/customerDto'
//import { EditOrder } from './EditOrder'


interface ICustomerProps {
    customer: CustomerDto;
}

interface CustomerrState {
    customer: CustomerDto;
    edit: boolean;
}


export class Customer extends React.Component<ICustomerProps, CustomerrState> {
    displayName = "Customer";

    constructor(props: ICustomerProps) {
        super(props);

        this.state = {
            customer: props.customer,
            edit: false
        }
    }

    onEdit() {
        this.setState({
            edit: true
        });
    }

    render() {
        var customer = this.state.customer;
        var edit: boolean = this.state.edit;
        return (
            <div>

                {
                    //edit &&
                    //<div className="order" >
                    //    <EditOrder order={order} type="update" onEdited={this.onEditedOrder.bind(this)} />
                    //</div>
                }

                {
                    edit === false &&
                    <div className="customer" >
                        

                        {                            
                            <div>
                                <div className="customer-item">
                                    Customer name: {customer.name}
                                </div>
                                <div className="order-item">
                                    Customer phone: {customer.phoneNo}
                                </div>
                                <div className="order-item">
                                    Customer email: {customer.email}
                                </div>
                            </div>
                        }
                        
                        <button onClick={this.onEdit.bind(this)} > Edit </button>
                    </div >
                }

            </div>
            );
    }
}