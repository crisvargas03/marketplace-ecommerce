import { Box, Divider, Image, Text } from '@chakra-ui/react';
import { AdminButton } from '../../ui/components/AdminButton';
import { MoreDetailsButton } from '../../ui/components/MoreDetailsButton';
import { CategoriesBadges } from '../../ui/components/CategoriesBadges';

const property = {
	imageUrls: [
		'https://images.unsplash.com/photo-1572635196237-14b3f281503f?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=4600&q=80',
		'https://images.unsplash.com/photo-1572635196237-14b3f281503f?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=4600&q=80',
	],
	name: 'Rayban sunglasses',
	description: 'loren1000',
	price: 1000,
	quantity: 50,
	category: ['category 1', 'category 2', 'category 3'],
};

const isAdmin = false;

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
				<Box mt='1' fontWeight='bold' fontSize='lg' as='h3'>
					{property.name}
				</Box>
				<Text
					color='gray.400'
					fontWeight='semibold'
					fontSize={'sm'}
					mt={2}>
					{property.quantity}
				</Text>
				<Divider marginY={3} />
				<CategoriesBadges categories={property.category} />
				<Divider marginY={3} />
				<Box display='flex' mt='2' justifyContent='space-between'>
					<Box mt='3'>${property.price}</Box>
					<Box mt='3'>
						{isAdmin ? <AdminButton /> : <MoreDetailsButton />}
					</Box>
				</Box>
			</Box>
		</Box>
	);
}
