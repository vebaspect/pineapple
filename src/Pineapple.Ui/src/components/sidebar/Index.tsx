import React, { useEffect, useState } from 'react';

import Implementations from './implementations';
import Products from './products';

const Sidebar = () => {
  // Flaga określająca, czy lista wdrożeń została pobrana z API.
  const [isImplementationsFetched, setIsImplementationsFetched] = React.useState(false);
  // Flaga określająca, czy lista produktów została pobrana z API.
  const [isProductsFetched, setIsProductsFetched] = React.useState(false);
  // Lista wdrożeń.
  const [implementations, setImplementations] = useState([]);
  // Lista produktów.
  const [products, setProducts] = useState([]);

  useEffect(() => {
    fetchImplementations();
    fetchProducts();
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
    </>
  )
}

export default Sidebar;
