import React, { useState } from 'react';
import { Link as RouterLink, useLocation } from 'react-router-dom';

import CircularProgress from '@material-ui/core/CircularProgress';
import Collapse from '@material-ui/core/Collapse';
import ExpandLess from '@material-ui/icons/ExpandLess';
import ExpandMore from '@material-ui/icons/ExpandMore';
import Link from '@material-ui/core/Link';
import List from '@material-ui/core/List';
import ListItem from '@material-ui/core/ListItem';
import ListItemIcon from '@material-ui/core/ListItemIcon';
import ListItemText from '@material-ui/core/ListItemText';

import SettingsIcon from '@material-ui/icons/Settings';

import {
  ConfigurationProps,
} from './interfaces';

const Configuration: React.FC<ConfigurationProps> = ({ isComponentTypesCountFetched, componentTypesCount, isOperatingSystemsCountFetched, operatingSystemsCount, isSoftwareApplicationsCountFetched, softwareApplicationsCount }: ConfigurationProps) => {
  const location = useLocation();

  // Flaga określająca, czy gałąź "Konfiguracja" jest rozwinięta.
  const [isExpanded, setIsExpanded] = useState(false);

  const onExpandLessButtonClick = () => {
    setIsExpanded(false);
  }

  const onExpandMoreButtonClick = () => {
    setIsExpanded(true);
  }

  if (!isComponentTypesCountFetched && !isOperatingSystemsCountFetched && !isSoftwareApplicationsCountFetched) {
    return (
      <ListItem>
        <ListItemIcon>
          <SettingsIcon color="primary" />
        </ListItemIcon>
        <ListItemText>
          Konfiguracja
        </ListItemText>
        <CircularProgress size={20} />
      </ListItem>
    );
  }

  return (
    <>
      <ListItem
        button
        style={
          location.pathname === '/configuration'
            ? { backgroundColor: '#f2f4ff' }
            : null
        }
      >
        <ListItemIcon>
          <SettingsIcon color="primary" />
        </ListItemIcon>
        <ListItemText>
          <Link
            component={RouterLink}
            to="/configuration"
          >
            Konfiguracja
          </Link>
        </ListItemText>
        {isExpanded ? <ExpandLess onClick={onExpandLessButtonClick} /> : <ExpandMore onClick={onExpandMoreButtonClick} />}
      </ListItem>
      <Collapse
        in={isExpanded}
        style={{ paddingLeft: '56px' }}
      >
        <List component="div">
          <ListItem
            button
            style={
              location.pathname === '/configuration/component-types'
                ? { backgroundColor: '#f2f4ff' }
                : null
            }
          >
            <ListItemText>
              <Link
                component={RouterLink}
                to="/configuration/component-types"
                style={{ fontSize: '0.9rem' }}
              >
                Typy komponentów ({componentTypesCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem
            button
            style={
              location.pathname === '/configuration/operating-systems'
                ? { backgroundColor: '#f2f4ff' }
                : null
            }
          >
            <ListItemText>
              <Link
                component={RouterLink}
                to="/configuration/operating-systems"
                style={{ fontSize: '0.9rem' }}
              >
                Systemy operacyjne ({operatingSystemsCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem
            button
            style={
              location.pathname === '/configuration/software-applications'
                ? { backgroundColor: '#f2f4ff' }
                : null
            }
          >
            <ListItemText>
              <Link
                component={RouterLink}
                to="/configuration/software-applications"
                style={{ fontSize: '0.9rem' }}
              >
                Oprogramowanie ({softwareApplicationsCount})
              </Link>
            </ListItemText>
          </ListItem>
        </List>
      </Collapse>
    </>
  )
}

export default Configuration;
