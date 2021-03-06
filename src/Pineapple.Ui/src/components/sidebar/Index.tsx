import React, { useEffect, useState } from 'react';

import List from '@material-ui/core/List';
import Paper from '@material-ui/core/Paper';

import Configuration from './configuration';
import Home from './home';
import Implementations from './implementations';
import Products from './products';
import Users from './users';

const Sidebar: React.VFC = () => {
  // Flaga określająca, czy drzewo wdrożeń zostało pobrane z API.
  const [isImplementationsTreeFetched, setIsImplementationsTreeFetched] = useState(false);
  // Drzewo wdrożeń.
  const [implementationsTree, setImplementationsTree] = useState({ implementations: [] });

  // Flaga określająca, czy drzewo produktów zostało pobrane z API.
  const [isProductsTreeFetched, setIsProductsTreeFetched] = useState(false);
  // Drzewo produktów.
  const [productsTree, setProductsTree] = useState({ products: [] });

  // Flaga określająca, czy liczba typów komponentów została pobrana z API.
  const [isComponentTypesCountFetched, setIsComponentTypesCountFetched] = useState(false);
  // Liczba typów komponentów.
  const [componentTypesCount, setComponentTypesCount] = useState(0);
  // Flaga określająca, czy liczba systemów operacyjnych została pobrana z API.
  const [isOperatingSystemsCountFetched, setIsOperatingSystemsCountFetched] = useState(false);
  // Liczba systemów operacyjnych.
  const [operatingSystemsCount, setOperatingSystemsCount] = useState(0);
  // Flaga określająca, czy liczba oprogramowania została pobrana z API.
  const [isSoftwareApplicationsCountFetched, setIsSoftwareApplicationsCountFetched] = useState(false);
  // Liczba oprogramowania.
  const [softwareApplicationsCount, setSoftwareApplicationsCount] = useState(0);

  // Flaga określająca, czy liczba programistów została pobrana z API.
  const [isDevelopersCountFetched, setIsDevelopersCountFetched] = useState(false);
  // Liczba programistów.
  const [developersCount, setDevelopersCount] = useState(0);
  // Flaga określająca, czy liczba wdrożeniowców została pobrana z API.
  const [isOperatorsCountFetched, setIsOperatorsCountFetched] = useState(false);
  // Liczba wdrożeniowców.
  const [operatorsCount, setOperatorsCount] = useState(0);
  // Flaga określająca, czy liczba menedżerów pobrana z API.
  const [isManagersCountFetched, setIsManagersCountFetched] = useState(false);
  // Liczba menedżerów.
  const [managersCount, setManagersCount] = useState(0);
  // Flaga określająca, czy liczba administratorów została pobrana z API.
  const [isAdministratorsCountFetched, setIsAdministratorsCountFetched] = useState(false);
  // Liczba administratorów.
  const [administratorsCount, setAdministratorsCount] = useState(0);

  const fetchImplementationsTree = async () => {
    await fetch(`${window['env'].API_URL}/implementations/tree`)
      .then((response) => response.json())
      .then((data) => {
        setIsImplementationsTreeFetched(true);
        setImplementationsTree(data);
      });
  };

  const fetchProductsTree = async () => {
    await fetch(`${window['env'].API_URL}/products/tree`)
      .then((response) => response.json())
      .then((data) => {
        setIsProductsTreeFetched(true);
        setProductsTree(data);
      });
  };

  const fetchComponentTypesCount = async () => {
    await fetch(`${window['env'].API_URL}/configuration/component-types/count`)
      .then((response) => response.json())
      .then((data) => {
        setIsComponentTypesCountFetched(true);
        setComponentTypesCount(data.value);
      });
  }

  const fetchOperatingSystemsCount = async () => {
    await fetch(`${window['env'].API_URL}/configuration/operating-systems/count`)
      .then((response) => response.json())
      .then((data) => {
        setIsOperatingSystemsCountFetched(true);
        setOperatingSystemsCount(data.value);
      });
  }

  const fetchSoftwareApplicationsCount = async () => {
    await fetch(`${window['env'].API_URL}/configuration/software-applications/count`)
      .then((response) => response.json())
      .then((data) => {
        setIsSoftwareApplicationsCountFetched(true);
        setSoftwareApplicationsCount(data.value);
      });
  }

  const fetchDevelopersCount = async () => {
    await fetch(`${window['env'].API_URL}/users/developers/count`)
      .then((response) => response.json())
      .then((data) => {
        setIsDevelopersCountFetched(true);
        setDevelopersCount(data.value);
      });
  }

  const fetchOperatorsCount = async () => {
    await fetch(`${window['env'].API_URL}/users/operators/count`)
      .then((response) => response.json())
      .then((data) => {
        setIsOperatorsCountFetched(true);
        setOperatorsCount(data.value);
      });
  }

  const fetchManagersCount = async () => {
    await fetch(`${window['env'].API_URL}/users/managers/count`)
      .then((response) => response.json())
      .then((data) => {
        setIsManagersCountFetched(true);
        setManagersCount(data.value);
      });
  }

  const fetchAdministratorsCount = async () => {
    await fetch(`${window['env'].API_URL}/users/administrators/count`)
      .then((response) => response.json())
      .then((data) => {
        setIsAdministratorsCountFetched(true);
        setAdministratorsCount(data.value);
      });
  }

  useEffect(() => {
    fetchImplementationsTree();
    fetchProductsTree();
    fetchComponentTypesCount();
    fetchOperatingSystemsCount();
    fetchSoftwareApplicationsCount();
    fetchDevelopersCount();
    fetchOperatorsCount();
    fetchManagersCount();
    fetchAdministratorsCount();
  }, []);

  return (
    <Paper>
      <List component="nav">
        <Home />
        <Implementations
          isDataFetched={isImplementationsTreeFetched}
          data={implementationsTree}
        />
        <Products
          isDataFetched={isProductsTreeFetched}
          data={productsTree}
        />
        <Configuration
          isComponentTypesCountFetched={isComponentTypesCountFetched}
          componentTypesCount={componentTypesCount}
          isOperatingSystemsCountFetched={isOperatingSystemsCountFetched}
          operatingSystemsCount={operatingSystemsCount}
          isSoftwareApplicationsCountFetched={isSoftwareApplicationsCountFetched}
          softwareApplicationsCount={softwareApplicationsCount}
        />
        <Users
          isDevelopersCountFetched={isDevelopersCountFetched}
          developersCount={developersCount}
          isOperatorsCountFetched={isOperatorsCountFetched}
          operatorsCount={operatorsCount}
          isManagersCountFetched={isManagersCountFetched}
          managersCount={managersCount}
          isAdministratorsCountFetched={isAdministratorsCountFetched}
          administratorsCount={administratorsCount}
        />
      </List>
    </Paper>
  )
}

export default Sidebar;
