import React from 'react';
import { Link as RouterLink } from 'react-router-dom';
import {
  Grid,
  Card,
  CardMedia,
  CardContent,
  Typography,
  Link,
} from '@mui/material';

const Home: React.FC<{ products: any[] }> = ({ products }) => (
  <Grid container spacing={3} style={{ marginTop: '20px' }}>
    {products.map((product) => (
      <Grid item xs={12} sm={6} md={4} key={product.id}>
        <Card sx={{ maxWidth: 345 }}>
          <CardMedia
            component="img"
            height="140"
            image={`https://via.placeholder.com/150?text=Post+${product.id}`}
            alt={product.title}
          />
          <CardContent>
            <Typography gutterBottom variant="h6" component="div">
              {product.title}
            </Typography>
            <Typography variant="body2" color="text.secondary">
              {product.body.substring(0, 80)}...
            </Typography>
            <Link component={RouterLink} to={`/details/${product.id}`}>
              Details
            </Link>
          </CardContent>
        </Card>
      </Grid>
    ))}
  </Grid>
);

export default Home;
