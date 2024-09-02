import { Box, Divider, Image } from '@chakra-ui/react';

const property = {
	imageUrls: [
		'https://images.unsplash.com/photo-1572635196237-14b3f281503f?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=4600&q=80',
	],
	name: 'Rayban sunglasses',
	description: 'loren1000',
	price: 1000,
	category: ['category 1', 'catgory 2'],
};

export function ProductCard() {
	return (
		<Box maxW={300} borderWidth='2px' borderRadius='md' overflow='hidden'>
			<Image
				width={500}
				height={300}
				src={property.imageUrls[0]}
				alt={property.description}
			/>

			<Box p='2'>
				<Box mt='1' mb='2' fontWeight='semibold' fontSize='md' as='h3'>
					{property.name}
				</Box>
				<Divider />

				<Box display='flex' mt='2' justifyContent='space-between'>
					<Box mt='3'>${property.price}</Box>
					<Box mt='3'>View More Details</Box>
				</Box>
			</Box>
		</Box>
	);
}
