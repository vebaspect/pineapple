import React, { useEffect, useState } from 'react';

import Box from '@material-ui/core/Box';

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
    await fetch('http://localhost:5005/implementations')
      .then(response => response.json())
      .then(data => {
        setImplementations(data);
      });
  };

  const fetchProducts = async () => {
    await fetch('http://localhost:5005/products')
      .then(response => response.json())
      .then(data => {
        setProducts(data);
      });
  };

  return (
    <>
      <Box>
        Wdrożenia ({implementations.length})
      </Box>
      <Box>
        Produkty ({products.length})
      </Box>
    </>
  )
}

export default Sidebar;
