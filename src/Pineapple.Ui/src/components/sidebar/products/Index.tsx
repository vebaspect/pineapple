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
import Tooltip from '@material-ui/core/Tooltip';

import AppsIcon from '@material-ui/icons/Apps';

interface Props {
  // Flaga określająca, czy lista produktów została pobrana z API.
  isDataFetched: boolean,
  // Lista produktów.
  data: {
    // Identyfikator.
    id: string,
    // Nazwa.
    name: string,
    // Opis.
    description: string,
  }[];
};

const Products = ({ isDataFetched, data }: Props) => {
  // Flaga określająca, czy lista produktów jest rozwinięta.
  const [isExpanded, setIsExpanded] = useState(false);

  const onExpandLessButtonClick = () => {
    setIsExpanded(false);
  }

  const onExpandMoreButtonClick = () => {
    setIsExpanded(true);
  }

  if (!isDataFetched) {
    return (
      <ListItem>
        <ListItemIcon>
          <AppsIcon color="primary" />
        </ListItemIcon>
        <ListItemText>
          Produkty
        </ListItemText>
        <CircularProgress size={20} />
      </ListItem>
    );
  }

  return (
    <>
      <ListItem button>
        <ListItemIcon>
          <AppsIcon color="primary" />
        </ListItemIcon>
        <ListItemText>
          <Link
            component={RouterLink}
            to="/products"
          >
            Produkty ({data.length})
          </Link>
        </ListItemText>
        {isExpanded ? <ExpandLess onClick={onExpandLessButtonClick} /> : <ExpandMore onClick={onExpandMoreButtonClick} />}
      </ListItem>
      <Collapse
        in={isExpanded}
        style={{ paddingLeft: '56px' }}
      >
        <List component="div">
          {
            data.length > 0
              ? data.map(product => {
                return (
                  <Tooltip key={product.id} title={product.description} placement="right">
                    <ListItem button>
                      <ListItemText>
                        <Link
                          component={RouterLink}
                          to={`/products/${product.id}`}
                          style={{ fontSize: '0.9rem' }}
                        >
                          {product.name}
                        </Link>
                      </ListItemText>
                    </ListItem>
                  </Tooltip>
                )
              })
              : null
          }
        </List>
      </Collapse>
    </>
  )
}

export default Products;
