import { NavigationContainer } from '@react-navigation/native';
import { createNativeStackNavigator } from '@react-navigation/native-stack';
import { useState } from 'react';
import { TouchableHighlight } from 'react-native'

import Home from './Home';

import resources from './resources.json';


const Stack = createNativeStackNavigator();

export default function Navigation() {
    return (
        <NavigationContainer >
            <Stack.Navigator>
                <Stack.Screen
                    name={resources.screens.home}
                    component={Home}

                    options={{
                    }}
                />
            </Stack.Navigator>
        </NavigationContainer>
    );
}