import React from 'react';
import {
  Route,
  Switch,
} from 'react-router-dom';

import Administrators from './administrators';
import Component from './component';
import ComponentType from './componentType';
import ComponentTypes from './componentTypes';
import ComponentVersion from './componentVersion';
import Configuration from './configuration';
import Developers from './developers';
import Environment from './environment';
import Home from './home';
import Implementation from './implementation';
import Implementations from './implementations';
import Managers from './managers';
import OperatingSystem from './operatingSystem';
import OperatingSystems from './operatingSystems';
import Operators from './operators';
import Product from './product';
import Products from './products';
import Server from './server';
import SoftwareApplication from './softwareApplication';
import SoftwareApplications from './softwareApplications';
import User from './user';
import Users from './users'

import CreateAdministratorEditor from '../editors/users/createAdministratorEditor';
import CreateComponentEditor from '../editors/products/createComponentEditor';
import CreateComponentTypeEditor from '../editors/configuration/createComponentTypeEditor';
import CreateComponentVersionEditor from '../editors/products/createComponentVersionEditor';
import CreateDeveloperEditor from '../editors/users/createDeveloperEditor';
import CreateEnvironmentEditor from '../editors/implementations/createEnvironmentEditor';
import CreateImplementationEditor from '../editors/implementations/createImplementationEditor';
import CreateManagerEditor from '../editors/users/createManagerEditor';
import CreateOperatingSystemEditor from '../editors/configuration/createOperatingSystemEditor';
import CreateOperatorEditor from '../editors/users/createOperatorEditor';
import CreateProductEditor from '../editors/products/createProductEditor';
import CreateServerEditor from '../editors/implementations/createServerEditor';
import CreateSoftwareApplicationEditor from '../editors/configuration/createSoftwareApplicationEditor';
import InstallServerComponentEditor from '../editors/implementations/installServerComponentEditor';
import InstallServerSoftwareApplicationEditor from '../editors/implementations/installServerSoftwareApplicationEditor';
import UpdateServerComponentEditor from '../editors/implementations/updateServerComponentEditor';

const Title: React.VFC = () => {
  return (
    <Switch>
      <Route path="/configuration/component-types/create">
        <CreateComponentTypeEditor />
      </Route>
      <Route path="/configuration/component-types/:componentTypeId">
        <ComponentType />
      </Route>
      <Route path="/configuration/component-types">
        <ComponentTypes />
      </Route>
      <Route path="/configuration/operating-systems/create">
        <CreateOperatingSystemEditor />
      </Route>
      <Route path="/configuration/operating-systems/:operatingSystemId">
        <OperatingSystem />
      </Route>
      <Route path="/configuration/operating-systems">
        <OperatingSystems />
      </Route>
      <Route path="/configuration/software-applications/create">
        <CreateSoftwareApplicationEditor />
      </Route>
      <Route path="/configuration/software-applications/:softwareApplicationId">
        <SoftwareApplication />
      </Route>
      <Route path="/configuration/software-applications">
        <SoftwareApplications />
      </Route>
      <Route path="/configuration">
        <Configuration />
      </Route>
      <Route path="/implementations/create">
        <CreateImplementationEditor />
      </Route>
      <Route path="/implementations/:implementationId/environments/:environmentId/servers/:serverId/components/install">
        <InstallServerComponentEditor />
      </Route>
      <Route path="/implementations/:implementationId/environments/:environmentId/servers/:serverId/components/update/:serverComponentId">
        <UpdateServerComponentEditor />
      </Route>
      <Route path="/implementations/:implementationId/environments/:environmentId/servers/:serverId/software-applications/install">
        <InstallServerSoftwareApplicationEditor />
      </Route>
      <Route path="/implementations/:implementationId/environments/:environmentId/servers/create">
        <CreateServerEditor />
      </Route>
      <Route path="/implementations/:implementationId/environments/:environmentId/servers/:serverId">
        <Server />
      </Route>
      <Route path="/implementations/:implementationId/environments/create">
        <CreateEnvironmentEditor />
      </Route>
      <Route path="/implementations/:implementationId/environments/:environmentId">
        <Environment />
      </Route>
      <Route path="/implementations/:implementationId">
        <Implementation />
      </Route>
      <Route path="/implementations">
        <Implementations />
      </Route>
      <Route path="/products/create">
        <CreateProductEditor />
      </Route>
      <Route path="/products/:productId/components/:componentId/component-versions/create">
        <CreateComponentVersionEditor />
      </Route>
      <Route path="/products/:productId/components/:componentId/component-versions/:componentVersionId">
        <ComponentVersion />
      </Route>
      <Route path="/products/:productId/components/create">
        <CreateComponentEditor />
      </Route>
      <Route path="/products/:productId/components/:componentId">
        <Component />
      </Route>
      <Route path="/products/:productId">
        <Product />
      </Route>
      <Route path="/products">
        <Products />
      </Route>
      <Route path="/users/administrators/create">
        <CreateAdministratorEditor />
      </Route>
      <Route path="/users/administrators">
        <Administrators />
      </Route>
      <Route path="/users/developers/create">
        <CreateDeveloperEditor />
      </Route>
      <Route path="/users/developers">
        <Developers />
      </Route>
      <Route path="/users/managers/create">
        <CreateManagerEditor />
      </Route>
      <Route path="/users/managers">
        <Managers />
      </Route>
      <Route path="/users/operators/create">
        <CreateOperatorEditor />
      </Route>
      <Route path="/users/operators">
        <Operators />
      </Route>
      <Route path="/users/:userId">
        <User />
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
