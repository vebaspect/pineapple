import React from 'react';

import Box from '@material-ui/core/Box';

interface Props {
    items: {
        name: string,
        description: string,
    }[];
};

const Products = ({ items } : Props) => {
  return (
    <>
      <Box>
        Produkty ({items.length})
      </Box>
    </>
  )
}

export default Products;
