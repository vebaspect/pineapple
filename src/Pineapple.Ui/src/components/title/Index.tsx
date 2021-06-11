import React from 'react';

import Box from '@material-ui/core/Box';

const Title: React.VFC = () => {
  return (
    <Box
      m={2}
      textAlign="center"
      fontSize="0.9rem"
    >
      🍍 Pineapple
      <Box
        component="span"
        ml={0.5}
        fontSize="0.65rem"
      >
        (1.0.0-alpha.4)
      </Box>
    </Box>
  );
}

export default Title;
