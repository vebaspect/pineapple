import React from 'react';

import Container from '@material-ui/core/Container';
import CssBaseline from '@material-ui/core/CssBaseline';
import Grid from '@material-ui/core/Grid';
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles';

import Sidebar from './components/sidebar';
import Title from './components/title';

const Root = () => {
  const theme = createMuiTheme();

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Container>
        <Grid container>
          <Grid item xs={3}>
            <Title />
            <Sidebar />
          </Grid>
          <Grid item xs={9} />
        </Grid>
      </Container>
    </ThemeProvider>
  )
}

export default Root;
