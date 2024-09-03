import { Box, Divider, IconButton, Image, Text } from '@chakra-ui/react';
import { AdminButton } from '../../ui/components/AdminButton';
import { MoreDetailsButton } from '../../ui/components/MoreDetailsButton';
import { CategoriesBadges } from '../../ui/components/CategoriesBadges';
import { AddIcon } from '@chakra-ui/icons';

const property = {
	imageUrls: [
		'https://media.istockphoto.com/id/1346816410/photo/sunglasses-on-a-white-background.webp?a=1&s=612x612&w=0&k=20&c=AjSYVBSh-bkN0DjX5dr8zEh6aI-FCQkvrOdTdoSNnRY=',
		'https://images.unsplash.com/photo-1572635196237-14b3f281503f?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=4600&q=80',
	],
	name: 'Rayban sunglasses',
	description: 'loren1000',
	price: 1000,
	quantity: 10,
	category: ['category 1', 'category 2', 'category 3'],
};

const isAdmin = false;

export function ProductCard() {
	// TODO: Read data from props {name, imageUrls, description ...etc}
	const productAvailable = property.quantity === 0;

	const setQuantityColor = quantity => {
		if (quantity < 10) return 'red.500';
		if (quantity < 20) return 'yellow.500';

		return 'gray.500';
	};

	return (
		<Box maxW={300} borderWidth='2px' borderRadius='md' overflow='hidden'>
			<Image
				width={500}
				height={300}
				src={property.imageUrls[0]}
				alt={property.description}
			/>

			<Box p='2'>
				<Box
					display='flex'
					justifyContent='space-between'
					mt='1'
					fontWeight='bold'
					fontSize='lg'
					as='h3'>
					{property.name}

					<IconButton
						isDisabled={productAvailable}
						color='blue.500'
						icon={<AddIcon />}
					/>
				</Box>
				<Text
					color={setQuantityColor(property.quantity)}
					fontSize={'sm'}
					fontWeight='semibold'
					mt={2}>
					{productAvailable
						? 'No Available'
						: `${property.quantity} left in stock`}
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
