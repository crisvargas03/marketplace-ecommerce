import {
	Box,
	Container,
	Divider,
	Heading,
	Image,
	SimpleGrid,
	Stack,
	Text,
	VStack,
} from '@chakra-ui/react';
import { CategoriesBadges } from '../../ui/components/CategoriesBadges';
import { AddProductToCart } from '../components/AddProductToCart';

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
export function Details() {
	// TODO: read the information from the global Store

	return (
		<Container maxW={'7xl'}>
			<SimpleGrid
				columns={{ base: 1 }}
				spacing={{ base: 3 }}
				py={{ base: 18 }}>
				<Stack spacing={{ base: 6 }}>
					<Box as={'header'}>
						<Heading fontWeight='bold' fontSize={{ base: '2xl' }}>
							{property.name}
						</Heading>
						<Stack
							direction='row'
							alignItems='center'
							justifyContent='space-between'
							gap={10}>
							<Text color={'gray.900'} fontSize={'lg'}>
								${property.price}
							</Text>

							<Text
								color={'gray.900'}
								fontWeight={'semibold'}
								fontSize={'lg'}>
								Stock: {property.quantity}
							</Text>
						</Stack>
					</Box>

					<Stack spacing={{ base: 4 }} direction={'column'}>
						<VStack spacing={{ base: 4 }}>
							<Text fontSize={'lg'}>{property.description}</Text>
						</VStack>
						<Box>
							<CategoriesBadges
								fontSize='md'
								categories={property.category}
							/>
						</Box>
						<Divider />
						<Box>
							<Text
								fontSize={{ base: '16px' }}
								color={'blue.500'}
								fontWeight={'500'}
								textTransform={'uppercase'}
								mb={'4'}>
								Product Photos
							</Text>
							<Stack
								direction='row'
								alignItems='center'
								justifyContent={'center'}
								gap={10}>
								{property.imageUrls.map(image => (
									<Stack key={image}>
										<Image
											boxShadow='md'
											rounded={'md'}
											width={300}
											height={200}
											src={image}
										/>
									</Stack>
								))}
							</Stack>
						</Box>
					</Stack>
					<AddProductToCart />
				</Stack>
			</SimpleGrid>
		</Container>
	);
}
