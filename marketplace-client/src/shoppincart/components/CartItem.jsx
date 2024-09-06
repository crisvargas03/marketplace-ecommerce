import { IconButton, Image, Stack, Text } from '@chakra-ui/react';
import { AddProductToCart } from '../../ui';
import { DeleteIcon } from '@chakra-ui/icons';

const property = {
	imageUrls: [
		'https://media.istockphoto.com/id/1346816410/photo/sunglasses-on-a-white-background.webp?a=1&s=612x612&w=0&k=20&c=AjSYVBSh-bkN0DjX5dr8zEh6aI-FCQkvrOdTdoSNnRY=',
		'https://images.unsplash.com/photo-1572635196237-14b3f281503f?ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=4600&q=80',
	],
	name: 'Rayban sunglasses',
	description:
		'Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ad aliquid amet at delectus doloribus dolorum expedita hic, ipsum maxime modi nam officiis porro, quae, quisquam quos reprehenderit velit? Natus, totam.',
	price: 1000,
	quantity: 10,
	category: ['category 1', 'category 2', 'category 3'],
};

export function CartItem() {
	return (
		<Stack>
			<Stack
				p={2}
				rounded='md'
				boxShadow='md'
				mt={3}
				direction={'rows'}
				spacing={5}>
				<Image
					boxShadow='sm'
					rounded={'md'}
					width={170}
					height={200}
					src={property.imageUrls[1]}
				/>
				<Stack>
					<Text fontSize='lg' fontWeight='semibold'>
						{property.name}
					</Text>
					<Text>${property.price}</Text>
					<AddProductToCart />
					<Stack>
						<IconButton
							bg={'transparent'}
							_hover={{
								bg: 'transparent',
								color: 'red.300',
							}}
							mt={5}
							color='red.500'
							aria-label='Delete product'
							size='md'
							icon={<DeleteIcon />}
						/>
					</Stack>
				</Stack>
			</Stack>
		</Stack>
	);
}
