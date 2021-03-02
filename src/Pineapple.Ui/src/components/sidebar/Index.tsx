import React, { useEffect, useState } from 'react';

import Configuration from './configuration';
import Implementations from './implementations';
import Products from './products';

const Sidebar = () => {
  // Flaga określająca, czy lista wdrożeń została pobrana z API.
  const [isImplementationsFetched, setIsImplementationsFetched] = useState(false);
  // Lista wdrożeń.
  const [implementations, setImplementations] = useState([]);

  // Flaga określająca, czy lista produktów została pobrana z API.
  const [isProductsFetched, setIsProductsFetched] = useState(false);
  // Lista produktów.
  const [products, setProducts] = useState([]);

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

  useEffect(() => {
    fetchImplementations();
    fetchProducts();
    fetchComponentTypesCount();
    fetchOperatingSystemsCount();
    fetchSoftwareApplicationsCount();
  }, []);

  const fetchImplementations = async () => {
    await fetch(`${window['env'].API_URL}/implementations`)
      .then(response => response.json())
      .then(data => {
        setIsImplementationsFetched(true);
        setImplementations(data);
      });
  };

  const fetchProducts = async () => {
    await fetch(`${window['env'].API_URL}/products`)
      .then(response => response.json())
      .then(data => {
        setIsProductsFetched(true);
        setProducts(data);
      });
  };

  const fetchComponentTypesCount = async () => {
    await fetch(`${window['env'].API_URL}/configuration/component-types`)
      .then(response => response.json())
      .then(data => {
        setIsComponentTypesCountFetched(true);
        setComponentTypesCount(data.length);
      });
  }

  const fetchOperatingSystemsCount = async () => {
    await fetch(`${window['env'].API_URL}/configuration/operating-systems`)
      .then(response => response.json())
      .then(data => {
        setIsOperatingSystemsCountFetched(true);
        setOperatingSystemsCount(data.length);
      });
  }

  const fetchSoftwareApplicationsCount = async () => {
    await fetch(`${window['env'].API_URL}/configuration/software-applications`)
      .then(response => response.json())
      .then(data => {
        setIsSoftwareApplicationsCountFetched(true);
        setSoftwareApplicationsCount(data.length);
      });
  }

  return (
    <>
      <Implementations
        isDataFetched={isImplementationsFetched}
        data={implementations}
      />
      <Products
        isDataFetched={isProductsFetched}
        data={products}
      />
      <Configuration
        isComponentTypesCountFetched={isComponentTypesCountFetched}
        componentTypesCount={componentTypesCount}
        isOperatingSystemsCountFetched={isOperatingSystemsCountFetched}
        operatingSystemsCount={operatingSystemsCount}
        isSoftwareApplicationsCountFetched={isSoftwareApplicationsCountFetched}
        softwareApplicationsCount={softwareApplicationsCount}
      />
    </>
  )
}

export default Sidebar;
