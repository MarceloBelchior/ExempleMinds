import { Stack, Typography } from '@mui/material';
import React from 'react';
interface ItemsProps {
 title : string;
    price : number;
    location : string;  
    bedrooms : number;
    bathrooms : number;
}

const Items: React.FC<{props: ItemsProps}> = ({props}) => {
  return (
 <>
 <Stack>
    <Typography variant="h3" gutterBottom>
        {props.title}
    </Typography>
    <Typography variant="h6" gutterBottom>
        Price: {props.price}
    </Typography>
    <Typography variant="h6" gutterBottom>
        Location: {props.location}
    </Typography>
    <Typography variant="h6" gutterBottom>
        Bedrooms: {props.bedrooms}
    </Typography>
    <Typography variant="h6" gutterBottom>
        Bathrooms: {props.bathrooms}
    </Typography>
    
        
 </Stack>
 </>
  );
}

export default Items;