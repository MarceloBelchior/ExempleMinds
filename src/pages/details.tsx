import React, { useEffect, useState } from 'react';
import { useParams } from 'react-router-dom';
import { Container, Typography, Card, CardMedia, CardContent } from '@mui/material';

interface Product {
  id: number;
  title: string;
  body: string;
}

const Details: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const [product, setProduct] = useState<Product | null>(null);

  useEffect(() => {
    console.log('id', id);
    const fetchProduct = async () => {
      const response = await fetch(`https://jsonplaceholder.typicode.com/posts/${id}`);
      const data = await response.json();
      setProduct(data);
    };
    fetchProduct();
  }, [id]);

  if (!product) {
    return <Typography>Loading...</Typography>;
  }

  return (
    <Container maxWidth="sm" style={{ marginTop: '50px' }}>



      zzzzz
      <Card>
        <CardMedia
          component="img"
          height="200"
          image={`https://via.placeholder.com/600?text=Post+${product.id}`}
          alt={product.title}
        />
        <CardContent>
          <Typography variant="h4" gutterBottom>
            {product.title}
          </Typography>
          <Typography variant="body1">{product.body}</Typography>
        </CardContent>
      </Card>
    </Container>
  );
};

export default Details;
