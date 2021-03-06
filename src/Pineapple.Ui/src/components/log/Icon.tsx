import React from 'react';

import Avatar from '@material-ui/core/Avatar';

import AppsIcon from '@material-ui/icons/Apps';
import PowerIcon from '@material-ui/icons/Power';

import {
  LOG_TYPE__IMPLEMENTATION,
  LOG_TYPE__PRODUCT,
} from './constants';

interface Props {
  // Typ.
  type: string,
  // Kategoria.
  category: string,
};

const Icon = ({ type }: Props) => {
  let icon = null;

  switch (type) {
    case LOG_TYPE__IMPLEMENTATION:
      icon = <PowerIcon />;
      break;
    case LOG_TYPE__PRODUCT:
      icon = <AppsIcon />;
      break;
    default:
      break;
  }

  return (
    <Avatar>
      {icon}
    </Avatar>
  )
}

export default Icon;
