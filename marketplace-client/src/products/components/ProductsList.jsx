import { SimpleGrid } from '@chakra-ui/react';
import { ProductCard } from './ProductCard';

export function ProductsList() {
	// TODO: read list of products and use .map() with ProductCart (...operator)

	return (
		<SimpleGrid minChildWidth={250} spacing='20px'>
			<ProductCard />
		</SimpleGrid>
	);
}
