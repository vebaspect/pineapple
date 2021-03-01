import React from 'react';

import Box from '@material-ui/core/Box';

interface Props {
    items: {
        name: string,
        description: string,
    }[];
};

const Implementations = ({ items } : Props) => {
  return (
    <>
      <Box>
        Wdrożenia ({items.length})
      </Box>
    </>
  )
}

export default Implementations;
