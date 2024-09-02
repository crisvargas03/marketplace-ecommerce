import { SimpleGrid } from '@chakra-ui/react';
import { ProductCard } from './ProductCard';

export function ProductsList() {
	return (
		<SimpleGrid minChildWidth={250} spacing='20px'>
			<ProductCard />
			<ProductCard />
			<ProductCard />
			<ProductCard />
			<ProductCard />
		</SimpleGrid>
	);
}
