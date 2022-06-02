FROM node:16.13.0 as build

COPY ./ App/
WORKDIR /App/

RUN npm install
RUN npm run build

FROM nginx:latest
COPY --from=build /App/dist/final-ui/ /usr/share/nginx/html/

EXPOSE 80