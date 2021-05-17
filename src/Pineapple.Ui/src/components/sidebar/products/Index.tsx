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

import {
  ProductsProps,
} from './interfaces';

const Products: React.FC<ProductsProps> = ({ isDataFetched, data }: ProductsProps) => {
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
            Produkty ({data.products?.filter((product) => !product.isDeleted).length})
          </Link>
        </ListItemText>
        {
          data.products?.length
            ? (isExpanded ? <ExpandLess onClick={onExpandLessButtonClick} /> : <ExpandMore onClick={onExpandMoreButtonClick} />)
            : null 
        }
      </ListItem>
      <Collapse
        in={isExpanded}
        style={{ paddingLeft: '56px' }}
      >
        <List component="div">
          {
            data.products?.length > 0
              ? data.products.filter((product) => !product.isDeleted).map((product) => {
                return (
                  <React.Fragment key={product.id}>
                    <ListItem
                      button
                      style={{ paddingBottom: '4px', paddingTop: '4px' }}
                    >
                      <ListItemText>
                        <Tooltip title={product.description} placement="right">
                          <Link
                            component={RouterLink}
                            to={`/products/${product.id}`}
                            style={{ fontSize: '0.9rem' }}
                          >
                            {product.name}
                          </Link>
                        </Tooltip>
                      </ListItemText>
                    </ListItem>
                    {
                      product.components?.length > 0
                        ? product.components.filter((component) => !component.isDeleted).map((component) => {
                          return (
                            <React.Fragment key={component.id}>
                              <ListItem
                                button
                                style={{ paddingBottom: '2px', paddingLeft: '32px', paddingTop: '2px' }}
                              >
                                <ListItemText style={{ marginBottom: '0', marginTop: '0' }}>
                                  <Tooltip title={component.description} placement="right">
                                    <Link
                                      component={RouterLink}
                                      to={`/products/${product.id}/components/${component.id}`}
                                      style={{ fontSize: '0.75rem' }}
                                    >
                                      {component.name}
                                    </Link>
                                  </Tooltip>
                                </ListItemText>
                              </ListItem>
                            </React.Fragment>
                          );
                        })
                        : null
                    }
                  </React.Fragment>
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
