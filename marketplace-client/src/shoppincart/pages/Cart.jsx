import {
	Button,
	Grid,
	Heading,
	SimpleGrid,
	Stack,
	Text,
} from '@chakra-ui/react';
import { CartItem } from '../components/CartItem';

export function Cart() {
	return (
		<Grid p={15}>
			<Heading fontSize={'3xl'}>My Cart</Heading>
			<Text mt={5} fontSize={'lg'}>
				Cart Items
			</Text>
			<SimpleGrid columns={{ md: 2, sm: 1 }} spacing={5}>
				<Stack>
					<CartItem />
				</Stack>
				<Stack>
					<Stack p={2} rounded='md' boxShadow='md'>
						<Text mt={2} fontWeight={'semibold'} fontSize={'lg'}>
							Orden Details
						</Text>
						<SimpleGrid>
							<SimpleGrid
								p={2}
								pb={0}
								display={'flex'}
								columns={2}
								justifyContent={'space-between'}>
								<Text>Product Qant</Text>
								<Text>1 Item</Text>
							</SimpleGrid>
							<SimpleGrid
								p={2}
								pb={0}
								display={'flex'}
								columns={2}
								justifyContent={'space-between'}>
								<Text>SubTotal</Text>
								<Text>$1000</Text>
							</SimpleGrid>
							<SimpleGrid
								p={2}
								pb={0}
								display={'flex'}
								columns={2}
								justifyContent={'space-between'}>
								<Text>Tax (5%)</Text>
								<Text>$50</Text>
							</SimpleGrid>
							<SimpleGrid
								p={2}
								pb={0}
								display={'flex'}
								columns={2}
								fontSize={'lg'}
								fontWeight={'500'}
								justifyContent={'space-between'}>
								<Text>Total</Text>
								<Text>$1050</Text>
							</SimpleGrid>

							<Button
								rounded={'md'}
								mt={8}
								color={'blue.500'}
								textTransform={'uppercase'}>
								Continue to Checkout
							</Button>
						</SimpleGrid>
					</Stack>
				</Stack>
			</SimpleGrid>
		</Grid>
	);
}
