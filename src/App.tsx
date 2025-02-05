import React, { useEffect, useState } from 'react';
import {
  Container,
  Typography,
  Button,
  Pagination,
  Grid,
  Card,
  CardMedia,
  CardContent,
  TextField,
  IconButton,
  InputAdornment,
  Link,
} from '@mui/material';
import ClearIcon from '@mui/icons-material/Clear';
import { Link as RouterLink } from 'react-router-dom';

const App: React.FC = () => {
  const [listProducts, setListProducts] = useState<any[]>([]);
  const [currentPage, setCurrentPage] = useState(1);
  const [searchQuery, setSearchQuery] = useState('');
  const itemsPerPage = 6;

  const loadData = async () => {
    const response = await fetch('https://jsonplaceholder.typicode.com/posts');
    const data = await response.json();
    setListProducts(data);
  };

  useEffect(() => {
    loadData();
  }, []);

  // Filter posts based on search query
  const filteredProducts = listProducts.filter((product) =>
    product.title.toLowerCase().includes(searchQuery.toLowerCase())
  );

  // Calculate paginated data
  const totalPages = Math.ceil(filteredProducts.length / itemsPerPage);
  const paginatedData = filteredProducts.slice(
    (currentPage - 1) * itemsPerPage,
    currentPage * itemsPerPage
  );

  const handleSearchChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchQuery(event.target.value);
    setCurrentPage(1); 
  };

  const handleClearSearch = () => {
    setSearchQuery('');
    setCurrentPage(1); 
  };

  return (
    <Container maxWidth="md" style={{ textAlign: 'center', marginTop: '50px' }}>
      <Typography variant="h3" gutterBottom>
        Welcome to My React App
      </Typography>
      <Button variant="contained" color="primary" style={{ marginRight: 10 }}>
        Click Me
      </Button>
      <Button variant="contained" color="secondary" onClick={loadData}>
        Load Data
      </Button>

      {/* Search Filter */}
      <TextField
        label="Search by Title"
        variant="outlined"
        value={searchQuery}
        onChange={handleSearchChange}
        fullWidth
        margin="normal"
        InputProps={{
          endAdornment: searchQuery && (
            <InputAdornment position="end">
              <IconButton onClick={handleClearSearch}>
                <ClearIcon />
              </IconButton>
            </InputAdornment>
          ),
        }}
      />

      {/* Display List with Cards */}
      <Grid container spacing={3} style={{ marginTop: '20px' }}>
        {paginatedData.map((product) => (
          <Grid item xs={12} sm={6} md={4} key={product.id}>
            <Card sx={{ maxWidth: 345 }}>
              <CardMedia
                component="img"
                height="140"
                image={`https://via.placeholder.com/150?text=Post+${product.id}`} // Placeholder image
                alt={product.title}
              />
              <CardContent>
                <Typography gutterBottom variant="h6" component="div">
                  {product.title}
                </Typography>
                <Typography variant="body2" color="text.secondary">
                  {product.body.substring(0, 80)}...
                </Typography>
                <a href={`/details/${product.id}`}> Details {product.id} </a>
                </CardContent>
            </Card>
          </Grid>
        ))}
      </Grid>

      {/* Pagination Component */}
      {filteredProducts.length > 0 && (
        <Pagination
          count={totalPages}
          page={currentPage}
          onChange={(_, page) => setCurrentPage(page)}
          color="primary"
          style={{ marginTop: '20px' }}
        />
      )}
    </Container>
  );
};

export default App;
