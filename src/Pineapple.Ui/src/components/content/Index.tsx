import React from 'react';
import {
  Route,
  Switch,
} from "react-router-dom";

import Administrators from './administrators';
import ComponentTypes from './componentTypes';
import Configuration from './configuration';
import Developers from './developers';
import Home from './home';
import Implementation from './implementation';
import Implementations from './implementations';
import Managers from './managers';
import OperatingSystems from './operatingSystems';
import Operators from './operators';
import Product from './product';
import Products from './products';
import SoftwareApplications from './softwareApplications';
import Users from './users'

import CreateComponentTypeEditor from '../editors/configuration/createComponentTypeEditor';
import CreateImplementationEditor from '../editors/implementations/createImplementationEditor';
import CreateProductEditor from '../editors/products/createProductEditor';

const Title = () => {
  return (
    <Switch>
      <Route path="/administrators">
        <Administrators />
      </Route>
      <Route path="/component-types/create">
        <CreateComponentTypeEditor />
      </Route>
      <Route path="/component-types">
        <ComponentTypes />
      </Route>
      <Route path="/configuration">
        <Configuration />
      </Route>
      <Route path="/developers">
        <Developers />
      </Route>
      <Route path="/implementations/create">
        <CreateImplementationEditor />
      </Route>
      <Route path="/implementations/:implementationId">
        <Implementation />
      </Route>
      <Route path="/implementations">
        <Implementations />
      </Route>
      <Route path="/managers">
        <Managers />
      </Route>
      <Route path="/operating-systems">
        <OperatingSystems />
      </Route>
      <Route path="/operators">
        <Operators />
      </Route>
      <Route path="/products/create">
        <CreateProductEditor />
      </Route>
      <Route path="/products/:productId">
        <Product />
      </Route>
      <Route path="/products">
        <Products />
      </Route>
      <Route path="/software-applications">
        <SoftwareApplications />
      </Route>
      <Route path="/users">
        <Users />
      </Route>
      <Route path="/">
        <Home />
      </Route>
    </Switch>
  );
}

export default Title;
