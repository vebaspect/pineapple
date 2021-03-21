import moment from 'moment';
import 'moment/locale/pl';
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
  moment.locale('pl');

  const theme = createMuiTheme({
    palette: {
      background: {
        default: '#f5f5f5',
      },
    },
  });

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
