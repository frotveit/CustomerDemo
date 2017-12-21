import * as React from 'react';
import { NavLink, Link } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <div className='main-nav'>
                <div className='navbar navbar-inverse'>
                <div className='navbar-header'>
                    <button type='button' className='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                        <span className='sr-only'>Toggle navigation</span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                        <span className='icon-bar'></span>
                    </button>
                    <Link className='navbar-brand' to={ '/' }>CustomerDemo</Link>
                </div>
                <div className='clearfix'></div>
                <div className='navbar-collapse collapse'>
                    <ul className='nav navbar-nav'>
                        <li>
                            <NavLink exact to={ '/' } activeClassName='active'>
                                <span className='glyphicon glyphicon-home'></span> Home
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/newOrder'} activeClassName='active'>
                                <span className='glyphicon glyphicon-th-list'></span> NewOrder
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={ '/orders' } activeClassName='active'>
                                <span className='glyphicon glyphicon-education'></span> Orders
                            </NavLink>
                        </li>
                        <li>
                            <NavLink to={'/customers'} activeClassName='active'>
                                <span className='glyphicon glyphicon-education'></span> Customers
                            </NavLink>
                        </li>
                        
                    </ul>
                </div>
            </div>
        </div>;
    }
}
