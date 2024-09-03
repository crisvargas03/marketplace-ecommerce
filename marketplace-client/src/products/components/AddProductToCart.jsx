import { AddIcon, MinusIcon } from '@chakra-ui/icons';
import { Button, IconButton, Stack, Text } from '@chakra-ui/react';
import { useState } from 'react';

const quantity = 10;

export function AddProductToCart() {
	const [productToAddQuantity, setProductToAddQuantity] = useState(1);

	const addProductQuantity = () => {
		setProductToAddQuantity(prev => prev + 1);
	};

	const minusProductQuantity = () => {
		setProductToAddQuantity(prev => prev - 1);
	};
	return (
		<Stack>
			<Stack
				marginTop={8}
				direction='row'
				alignItems='center'
				justifyContent={'center'}
				gap={10}>
				<IconButton
					isDisabled={productToAddQuantity === 1}
					onClick={minusProductQuantity}
					color='blue.500'
					size='sm'
					icon={<MinusIcon />}
				/>
				<Text>{productToAddQuantity}</Text>
				<IconButton
					isDisabled={productToAddQuantity >= quantity}
					onClick={addProductQuantity}
					color='blue.500'
					size='sm'
					icon={<AddIcon />}
				/>
			</Stack>
			<Button
				rounded={'md'}
				mt={8}
				size={'md'}
				color={'blue.500'}
				textTransform={'uppercase'}>
				Add to cart
			</Button>
		</Stack>
	);
}
