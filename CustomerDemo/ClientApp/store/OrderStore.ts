/// <referencePath = "../../../node_modules/@types/jquery/index.d.ts">

import { Action, Reducer } from 'redux';
import { fetch, addTask } from 'domain-task';
import { OrderDto } from '../dto/orderDto';
import { Response } from '../dto/response';
import * as $ from 'jquery';

const url = "api/order";

interface SaveOrderResponse extends Response {    
    Order: OrderDto;
}

export default class OrderStore {

    public static orders(): JQuery.jqXHR<OrderDto[]> {
        return $.ajax(url);
    }

    public static order(orderId: number): JQuery.jqXHR<OrderDto> {
        return $.ajax(url + "/" + orderId.toString());
    }

    public static saveOrder(order: OrderDto): JQuery.jqXHR<SaveOrderResponse> {
        return $.post(url, order, null, "json");
    }

    public static updateOrder(order: OrderDto): JQuery.jqXHR<SaveOrderResponse> {
        return $.ajax({
            url: url,
            type: "PUT",
            dataType: "json",
            data: order });
    }

    public static deleteOrder(order: OrderDto): JQuery.jqXHR<Response> {
        return $.ajax({
            url: url,
            type: "DELETE",
            dataType: "json",
            data: order
        });
    }
}