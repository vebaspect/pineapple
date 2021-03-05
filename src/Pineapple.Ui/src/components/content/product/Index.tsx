import React from 'react';
import { useParams } from 'react-router-dom';

const Product = () => {
  const { productId } = useParams();

  return (
    <>
      Produkt {productId}
    </>
  );
}

export default Product;
