import React, { useState } from 'react';
import { Link as RouterLink } from 'react-router-dom';

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

interface Props {
  // Flaga określająca, czy liczba typów komponentów została pobrana z API.
  isComponentTypesCountFetched: boolean,
  // Liczba typów komponentów.
  componentTypesCount: number,
  // Flaga określająca, czy liczba systemów operacyjnych została pobrana z API.
  isOperatingSystemsCountFetched: boolean,
  // Liczba systemów operacyjnych.
  operatingSystemsCount: number,
  // Flaga określająca, czy liczba oprogramowania została pobrana z API.
  isSoftwareApplicationsCountFetched: boolean,
  // Liczba oprogramowania.
  softwareApplicationsCount: number,
}

const Configuration = ({ isComponentTypesCountFetched, componentTypesCount, isOperatingSystemsCountFetched, operatingSystemsCount, isSoftwareApplicationsCountFetched, softwareApplicationsCount }: Props) => {
  // Flaga określająca, czy konfiguracja jest rozwinięta.
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
      <ListItem button>
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
          <ListItem button>
            <ListItemText>
              <Link
                component={RouterLink}
                to="/component-types"
                style={{ fontSize: '0.9rem' }}
              >
                Typy komponentów ({componentTypesCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              <Link
                component={RouterLink}
                to="/operating-systems"
                style={{ fontSize: '0.9rem' }}
              >
                Systemy operacyjne ({operatingSystemsCount})
              </Link>
            </ListItemText>
          </ListItem>
          <ListItem button>
            <ListItemText>
              <Link
                component={RouterLink}
                to="/software-applications"
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
