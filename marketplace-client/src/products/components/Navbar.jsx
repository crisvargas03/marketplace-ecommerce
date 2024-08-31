/* eslint-disable react/prop-types */
import {
	Box,
	Flex,
	Avatar,
	HStack,
	Text,
	Button,
	Heading,
	Link as ChakraLink,
	Menu,
	MenuButton,
	MenuList,
	MenuItem,
	MenuDivider,
} from '@chakra-ui/react';
import { Link } from 'react-router-dom';
import { ArrowBackIcon } from '@chakra-ui/icons';

function MenuItemLink({ children, to, color = 'black' }) {
	return (
		<MenuItem>
			<ChakraLink
				color={color}
				style={{ textDecoration: 'none' }}
				as={Link}
				to={to}>
				{children}
			</ChakraLink>
		</MenuItem>
	);
}

export function NavBar() {
	return (
		<>
			<Box bg={'black'} px={4}>
				<Flex
					h={16}
					alignItems={'center'}
					justifyContent={'space-between'}
					mb={5}>
					<HStack spacing={8} alignItems={'center'}>
						<Box>
							<Heading color={'white'} fontSize={'xl'}>
								🛒 Marketplace
							</Heading>
						</Box>
					</HStack>
					<Flex alignItems={'center'}>
						<Text color={'white'} fontSize={'md'} mr={5}>
							Nombre.User
						</Text>
						<Menu>
							<MenuButton
								as={Button}
								rounded={'full'}
								variant={'link'}
								cursor={'pointer'}
								minW={0}>
								<Avatar size={'md'} src={''} />
							</MenuButton>
							<MenuList>
								<MenuItemLink to={'/products'}>
									Products
								</MenuItemLink>
								<MenuItemLink to={'/cart'}>Cart</MenuItemLink>
								<MenuItemLink>Orders</MenuItemLink>
								<MenuDivider />
								<MenuItem
									color={'red.500'}
									onClick={() => alert('Afuera')}>
									<ArrowBackIcon /> Logout
								</MenuItem>
							</MenuList>
						</Menu>
					</Flex>
				</Flex>
			</Box>
		</>
	);
}
