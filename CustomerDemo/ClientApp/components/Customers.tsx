import * as React from 'react';
import { Link, RouteComponentProps } from 'react-router-dom';
import CustomerStore from '../store/CustomerStore'
import { CustomerDto } from '../dto/customerDto'
import { Customer } from './Customer'

interface ICustomerProps extends RouteComponentProps<{}> {
}

interface ICustomersState {
    Customers: CustomerDto[];
}


export default class Customers extends React.Component<ICustomerProps, ICustomersState> {
    displayName = "Customers";

    constructor(props: ICustomerProps) {
        super(props);

        this.state = {
            Customers: []
        }

        CustomerStore.customers().then(r => {
            this.setState({
                Customers: r ? r : []
            })
        })
    }

    public render() {
        return <div>
            <h1> Customers </h1>
            {
                this.state.Customers.map(function (c: CustomerDto) {
                    return (
                        <Customer customer={c} />
                    )
                }, this)
            }
        </div>;
    }
}
