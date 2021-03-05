import React from 'react';
import { BrowserRouter } from 'react-router-dom';

import Container from '@material-ui/core/Container';
import CssBaseline from '@material-ui/core/CssBaseline';
import Grid from '@material-ui/core/Grid';
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles';

import Content from './components/content';
import Sidebar from './components/sidebar';
import Title from './components/title';

const Root = () => {
  const theme = createMuiTheme();

  return (
    <BrowserRouter>
      <ThemeProvider theme={theme}>
        <CssBaseline />
        <Container>
          <Grid container>
            <Grid item xs={3}>
              <Title />
              <Sidebar />
            </Grid>
            <Grid item xs={9}>
              <Content />
            </Grid>
          </Grid>
        </Container>
      </ThemeProvider>
    </BrowserRouter>
  )
}

export default Root;
