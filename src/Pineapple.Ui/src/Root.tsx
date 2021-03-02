import React from 'react';

import Container from '@material-ui/core/Container';
import CssBaseline from '@material-ui/core/CssBaseline';
import Grid from '@material-ui/core/Grid';
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles';

import Header from './components/header';
import Sidebar from './components/sidebar';

const Root = () => {
  const theme = createMuiTheme();

  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <Container>
        <Grid container>
          <Grid item xs={12}>
            <Header />
          </Grid>
        </Grid>
        <Grid container>
          <Grid item xs={3}>
            <Sidebar />
          </Grid>
          <Grid item xs={9} />
        </Grid>
      </Container>
    </ThemeProvider>
  )
}

export default Root;
