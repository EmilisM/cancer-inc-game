using Xunit;
using GameClient.Api;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;

namespace GameClient.Api.Tests
{
    public class UnitTests
    {
        public async void GetAttackTypesTest()
        {
            string baseUrl = "https://cancerincserver.azurewebsites.net/api/attacktype";

            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            Assert.NotNull(data);
                        }
                    }
                }
            }
        }
        [Fact()]
        public async void GetClassesTest()
        {
            string baseUrl = "https://cancerincserver.azurewebsites.net/api/class";

            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            var expected = "[{\"id\":1,\"name\":\"Red\",\"damageModifier\":2,\"speedModifier\":0.5},{\"id\":2,\"name\":\"White\",\"damageModifier\":0.5,\"speedModifier\":2},{\"id\":3,\"name\":\"Green\",\"damageModifier\":1,\"speedModifier\":1},{\"id\":4,\"name\":\"Yellow\",\"damageModifier\":1,\"speedModifier\":1}]";
                            Assert.NotNull(data);
                            Assert.Equal(expected, data);
                        }
                    }
                }
            }
        }

        [Fact()]
        public async void GetClassTest()
        {
            string baseUrl = "https://cancerincserver.azurewebsites.net/api/class/1";

            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            Assert.NotNull(data);
                            Assert.Equal("{\"id\":1,\"name\":\"Red\",\"damageModifier\":2,\"speedModifier\":0.5}", data);
                        }
                    }
                }
            }
        }

        [Fact()]
        public async void GetEnemiesTest()
        {
            string baseUrl = "https://cancerincserver.azurewebsites.net/api/enemy";

            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            Assert.NotNull(data);
                        }
                    }
                }
            }
        }

        [Fact()]
        public async void GetEnemyTest()
        {
            string baseUrl = "https://cancerincserver.azurewebsites.net/api/enemy/1";

            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            Assert.NotNull(data);
                        }
                    }
                }
            }
        }

        [Fact()]
        public async void GetEnemyTypesTest()
        {
            string baseUrl = "https://cancerincserver.azurewebsites.net/api/enemytype/1";

            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            Assert.NotNull(data);
                        }
                    }
                }
            }
        }

        [Fact()]
        public async void GetAllEnemyTypesTest()
        {
            string baseUrl = "https://cancerincserver.azurewebsites.net/api/enemytype";

            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            Assert.NotNull(data);
                        }
                    }
                }
            }
        }

        [Fact()]
        public async void GetTowersTest()
        {
            string baseUrl = "https://cancerincserver.azurewebsites.net/api/tower";

            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            Assert.NotNull(data);
                        }
                    }
                }
            }
        }

        [Fact()]
        public async void GetTowerTest()
        {
            string baseUrl = "https://cancerincserver.azurewebsites.net/api/tower/1";

            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            Assert.NotNull(data);
                        }
                    }
                }
            }
        }

        [Fact()]
        public async void GetTowerAttackTypesTest()
        {
            string baseUrl = "https://cancerincserver.azurewebsites.net/api/tower/1/type";

            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            Assert.NotNull(data);
                        }
                    }
                }
            }
        }

        [Fact()]
        public async void GetTypesTest()
        {
            string baseUrl = "https://cancerincserver.azurewebsites.net/api/type";

            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            var expected = "[{\"id\":1,\"name\":\"Air\"},{\"id\":2,\"name\":\"Ground\"},{\"id\":3,\"name\":\"Invisible\"}]";
                            Assert.NotNull(data);
                            Assert.Equal(expected, data);
                        }
                    }
                }
            }
        }

        [Fact()]
        public async void GetTypeTest()
        {
            string baseUrl = "https://cancerincserver.azurewebsites.net/api/type/1";

            {
                using (HttpClient client = new HttpClient())
                {
                    using (HttpResponseMessage res = await client.GetAsync(baseUrl))
                    {
                        using (HttpContent content = res.Content)
                        {
                            var data = await content.ReadAsStringAsync();
                            var expected = "{\"id\":1,\"name\":\"Air\"}";
                            Assert.NotNull(data);
                            Assert.Equal(expected, data);
                        }
                    }
                }
            }
        }
    }
}