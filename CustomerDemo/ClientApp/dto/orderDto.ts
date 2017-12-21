
import { OrderItemDto } from "./orderItemDto"
import { CustomerDto } from "./customerDto"
import { LocationDto } from "./locationDto"


export interface OrderDto {
    orderId?: number;
    serviceDate?: Date;

    orderItems: OrderItemDto[];
    customer?: CustomerDto;
    location?: LocationDto;
    //location2?: LocationDto;
}



