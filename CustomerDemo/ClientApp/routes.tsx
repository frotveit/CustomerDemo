import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import Home from './components/Home';
import Orders from './components/Orders';
import Customers from './components/Customers';
import NewOrder from './components/NewOrder';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/orders' component={Orders} />
    <Route path='/customers' component={Customers} />
    <Route path='/newOrder' component={ NewOrder } />
</Layout>;
