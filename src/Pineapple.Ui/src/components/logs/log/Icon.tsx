import React from 'react';

import {
  createStyles,
  makeStyles,
  Theme,
} from '@material-ui/core/styles';

import Avatar from '@material-ui/core/Avatar';
import Box from '@material-ui/core/Box';

import AddIcon from '@material-ui/icons/Add';
import AppsIcon from '@material-ui/icons/Apps';
import BuildIcon from '@material-ui/icons/Build';
import CategoryIcon from '@material-ui/icons/Category';
import DeleteIcon from '@material-ui/icons/Delete';
import DesktopWindowsIcon from '@material-ui/icons/DesktopWindows';
import ExtensionIcon from '@material-ui/icons/Extension';
import NewReleasesIcon from '@material-ui/icons/NewReleases';
import PersonIcon from '@material-ui/icons/Person';
import PowerIcon from '@material-ui/icons/Power';
import ReportProblemIcon from '@material-ui/icons/ReportProblem';
import SaveIcon from '@material-ui/icons/Save';
import ShareIcon from '@material-ui/icons/Share';
import StorageIcon from '@material-ui/icons/Storage';

import {
  LOG_TYPE__COMPONENT,
  LOG_TYPE__COMPONENT_TYPE,
  LOG_TYPE__COMPONENT_VERSION,
  LOG_TYPE__ENVIRONMENT,
  LOG_TYPE__IMPLEMENTATION,
  LOG_TYPE__OPERATING_SYSTEM,
  LOG_TYPE__PRODUCT,
  LOG_TYPE__SERVER,
  LOG_TYPE__SERVER_COMPONENT,
  LOG_TYPE__SERVER_SOFTWARE_APPLICATION,
  LOG_TYPE__SOFTWARE_APPLICATION,
  LOG_TYPE__USER,
  LOG_CATEGORY__ADD_ENTITY,
  LOG_CATEGORY__REMOVE_ENTITY,
} from './constants';

const useStyles = makeStyles((theme: Theme) =>
  createStyles({
    unknownType: {
      backgroundColor: '#bdbdbd',
      color: '#fff',
    },
    unknownCategory: {
      backgroundColor: '#bdbdbd',
      color: '#fff',
      height: theme.spacing(2.75),
      width: theme.spacing(2.75),
    },
    component: {
      backgroundColor: '#3f51b5',
      color: '#fff',
    },
    componentType: {
      backgroundColor: '#ffac33',
      color: '#fff',
    },
    componentVersion: {
      backgroundColor: '#6573c3',
      color: '#fff',
    },
    environment: {
      backgroundColor: '#009688',
      color: '#fff',
    },
    implementation: {
      backgroundColor: '#00695f',
      color: '#fff',
    },
    operatingSystem: {
      backgroundColor: '#ffac33',
      color: '#fff',
    },
    product: {
      backgroundColor: '#2c387e',
      color: '#fff',
    },
    server: {
      backgroundColor: '#33ab9f',
      color: '#fff',
    },
    serverComponent: {
      backgroundColor: '#ff784e',
      color: '#fff',
    },
    serverSoftwareApplication: {
      backgroundColor: '#ff784e',
      color: '#fff',
    },
    softwareApplication: {
      backgroundColor: '#ffac33',
      color: '#fff',
    },
    user: {
      backgroundColor: '#af52bf',
      color: '#fff',
    },
    addEntity: {
      backgroundColor: '#4caf50',
      color: '#fff',
      height: theme.spacing(2.75),
      width: theme.spacing(2.75),
    },
    removeEntity: {
      backgroundColor: '#f44336',
      color: '#fff',
      height: theme.spacing(2.75),
      width: theme.spacing(2.75),
    },
  }),
);

import {
  IconProps,
} from './interfaces';

const Icon: React.FC<IconProps> = ({ type, category }: IconProps) => {
  const styles = useStyles();

  let typeIcon = null;
  let typeClassName = null;
  let categoryIcon = null;
  let categoryClassName = null;

  switch (type) {
    case LOG_TYPE__COMPONENT:
      typeIcon = <ExtensionIcon />;
      typeClassName = styles.component;
      break;
    case LOG_TYPE__COMPONENT_TYPE:
      typeIcon = <CategoryIcon />;
      typeClassName = styles.componentType;
      break;
    case LOG_TYPE__COMPONENT_VERSION:
      typeIcon = <NewReleasesIcon />;
      typeClassName = styles.componentVersion;
      break;
    case LOG_TYPE__ENVIRONMENT:
      typeIcon = <ShareIcon />;
      typeClassName = styles.environment;
      break;
    case LOG_TYPE__IMPLEMENTATION:
      typeIcon = <PowerIcon />;
      typeClassName = styles.implementation;
      break;
    case LOG_TYPE__OPERATING_SYSTEM:
      typeIcon = <DesktopWindowsIcon />;
      typeClassName = styles.operatingSystem;
      break;
    case LOG_TYPE__PRODUCT:
      typeIcon = <AppsIcon />;
      typeClassName = styles.product;
      break;
    case LOG_TYPE__SERVER:
      typeIcon = <StorageIcon />;
      typeClassName = styles.server;
      break;
    case LOG_TYPE__SERVER_COMPONENT:
      typeIcon = <BuildIcon />;
      typeClassName = styles.serverComponent;
      break;
    case LOG_TYPE__SERVER_SOFTWARE_APPLICATION:
      typeIcon = <BuildIcon />;
      typeClassName = styles.serverSoftwareApplication;
      break;
    case LOG_TYPE__SOFTWARE_APPLICATION:
      typeIcon = <SaveIcon />;
      typeClassName = styles.softwareApplication;
      break;
    case LOG_TYPE__USER:
      typeIcon = <PersonIcon />;
      typeClassName = styles.user;
      break;
    default:
      typeIcon = <ReportProblemIcon />;
      typeClassName = styles.unknownType;
      break;
  }

  switch (category) {
    case LOG_CATEGORY__ADD_ENTITY:
      categoryIcon = <AddIcon style={{ fontSize: 18 }} />;
      categoryClassName = styles.addEntity;
      break;
    case LOG_CATEGORY__REMOVE_ENTITY:
      categoryIcon = <DeleteIcon style={{ fontSize: 18 }} />;
      categoryClassName = styles.removeEntity;
      break;
    default:
      categoryIcon = <ReportProblemIcon style={{ fontSize: 18 }} />;
      categoryClassName = styles.unknownCategory;
      break;
  }

  return (
    <Box position="relative">
      <Box position="relative">
        <Avatar className={typeClassName}>
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
