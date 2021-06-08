module.exports = {
  preset: 'ts-jest',
  testEnvironment: 'node',
  collectCoverage: true,
  modulePathIgnorePatterns: ['<rootDir>/.stryker-tmp']
};