import MomentUtils from '@date-io/moment';
import moment from 'moment';
import 'moment/locale/pl';
import React from 'react';
import { BrowserRouter } from 'react-router-dom';

import Container from '@material-ui/core/Container';
import CssBaseline from '@material-ui/core/CssBaseline';
import Grid from '@material-ui/core/Grid';
import { createMuiTheme, ThemeProvider } from '@material-ui/core/styles';

import { MuiPickersUtilsProvider } from '@material-ui/pickers';

import Content from './components/content';
import Sidebar from './components/sidebar';
import Title from './components/title';

const locale = 'pl';

const Root: React.VFC = () => {
  moment.locale(locale);

  const theme = createMuiTheme({
    palette: {
      background: {
        default: '#f5f5f5',
      },
    },
  });

  return (
    <BrowserRouter>
      <MuiPickersUtilsProvider
        libInstance={moment}
        locale={locale}
        utils={MomentUtils}
      >
        <ThemeProvider theme={theme}>
          <CssBaseline />
          <Container>
            <Grid container spacing={2}>
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
      </MuiPickersUtilsProvider>
    </BrowserRouter>
  )
}

export default Root;
