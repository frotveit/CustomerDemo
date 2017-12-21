/// <referencePath = "../../../node_modules/@types/jquery/index.d.ts">

import { Action, Reducer } from 'redux';
import { fetch, addTask } from 'domain-task';
import { CustomerDto } from '../dto/customerDto';
import { Response } from '../dto/response';
import * as $ from 'jquery';

const url = "api/customer";

interface SaveCustomerResponse extends Response {
    Customer: CustomerDto;
}

export default class CustomerStore {

    public static customers(): JQuery.jqXHR<CustomerDto[]> {
        return $.ajax(url);
    }

    public static customer(customerId: number): JQuery.jqXHR<CustomerDto> {
        return $.ajax(url + "/" + customerId.toString());
    }

    public static saveCustomer(customer: CustomerDto): JQuery.jqXHR<SaveCustomerResponse> {
        return $.post(url, customer, null, "json");
    }

    public static updateCustomer(customer: CustomerDto): JQuery.jqXHR<SaveCustomerResponse> {
        return $.ajax({
            url: url,
            type: "PUT",
            dataType: "json",
            data: customer
        });
    }

    public static deleteCustomer(customer: CustomerDto): JQuery.jqXHR<Response> {
        return $.ajax({
            url: url,
            type: "DELETE",
            dataType: "json",
            data: customer
        });
    }
}