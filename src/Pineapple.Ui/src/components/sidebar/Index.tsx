import React, { useEffect, useState } from 'react';

import Implementations from './implementations';
import Products from './products';

const Sidebar = () => {
  // Wdrożenia.
  const [implementations, setImplementations] = useState([]);
  // Produkty.
  const [products, setProducts] = useState([]);

  useEffect(() => {
    fetchImplementations();
    fetchProducts();
  }, []);

  const fetchImplementations = async () => {
    await fetch(`${window['env'].API_URL}/implementations`)
      .then(response => response.json())
      .then(data => {
        setImplementations(data);
      });
  };

  const fetchProducts = async () => {
    await fetch(`${window['env'].API_URL}/products`)
      .then(response => response.json())
      .then(data => {
        setProducts(data);
      });
  };

  return (
    <>
      <Implementations items={implementations} />
      <Products items={products} />
    </>
  )
}

export default Sidebar;
