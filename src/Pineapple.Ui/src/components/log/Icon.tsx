import React from 'react';

import {
  green,
  indigo,
  red,
} from '@material-ui/core/colors';
import {
  createStyles,
  makeStyles,
  Theme,
} from '@material-ui/core/styles';

import Avatar from '@material-ui/core/Avatar';
import Box from '@material-ui/core/Box';

import AddIcon from '@material-ui/icons/Add';
import AppsIcon from '@material-ui/icons/Apps';
import DeleteIcon from '@material-ui/icons/Delete';
import PowerIcon from '@material-ui/icons/Power';
import SupervisorAccountIcon from '@material-ui/icons/SupervisorAccount';

import {
  LOG_TYPE__IMPLEMENTATION,
  LOG_TYPE__PRODUCT,
  LOG_TYPE__USER,
  LOG_CATEGORY__ADD_ENTITY,
  LOG_CATEGORY__REMOVE_ENTITY,
} from './constants';

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    categoryGreen: {
      backgroundColor: green[500],
      color: '#fff',
      height: theme.spacing(2.75),
      width: theme.spacing(2.75),
    },
    categoryRed: {
      backgroundColor: red[500],
      color: '#fff',
      height: theme.spacing(2.75),
      width: theme.spacing(2.75),
    },
    type: {
      backgroundColor: indigo[500],
      color: '#fff',
    },
  }),
);

interface Props {
  // Typ.
  type: string,
  // Kategoria.
  category: string,
};

const Icon = ({ type, category }: Props) => {
  const styles = useStyles();

  let typeIcon = null;
  let categoryIcon = null;
  let categoryClassName = null;

  switch (type) {
    case LOG_TYPE__IMPLEMENTATION:
      typeIcon = <PowerIcon />;
      break;
    case LOG_TYPE__PRODUCT:
      typeIcon = <AppsIcon />;
      break;
    case LOG_TYPE__USER:
      typeIcon = <SupervisorAccountIcon />;
      break;
    default:
      break;
  }

  switch (category) {
    case LOG_CATEGORY__ADD_ENTITY:
      categoryIcon = <AddIcon style={{ fontSize: 18 }} />;
      categoryClassName = styles.categoryGreen;
      break;
    case LOG_CATEGORY__REMOVE_ENTITY:
      categoryIcon = <DeleteIcon style={{ fontSize: 18 }} />;
      categoryClassName = styles.categoryRed;
      break;
    default:
      break;
  }

  return (
    <Box position="relative">
      <Box position="relative">
        <Avatar className={styles.type}>
          {typeIcon}
        </Avatar>
      </Box>
      <Box
        left={24}
        position="absolute"
        top={24}
      >
        <Avatar className={categoryClassName}>
          {categoryIcon}
        </Avatar>
      </Box>
    </Box>
  )
}

export default Icon;
