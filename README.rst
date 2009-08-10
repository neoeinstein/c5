==
C5
==
-----------------------------------------------------------
The Copenhagen Comprehensive Collection Classes for the CLI
-----------------------------------------------------------
**C5** is a generics collections library for the CLI [#]_ implemented by the .NET Framework and Mono. C5 is designed with the premise of programming to interface, thus all of the C5 collections implement a common set of interfaces which allow access to the full functionality of those collections. This is in contrast to the collections provided in the ``System.Collections.Generic`` namespace; many classes have additional useful functions that aren't exposed by their interfaces, even though commonalities exist.

Originally written by Niels Kokholm and Peter Sestoft at the `IT University of Copenhagen`__, the project is now being maintained openly. This repository is not sanctioned by Kokholm, Sestoft, or ITU, but takes up maintainership of this powerful library under the same license under which it was released. The last known release by Kokholm and Sestoft was v1.1.0, released on February 10, 2008.

__ `ITU C5`_

Organization
============
This repository is separated into 3 main branches, a tracking branch, and a documentation branch.

**master**
  This branch is the main line of development intended to work on the .NET 2.0 framework and equivalents. `Github master`_.
**contracts**
  This branch is based on ``master`` but also contains definitions for `code contracts`__. Code contracts are a .NET 4.0 feature, also released as a library and utility in pre-4.0 versions of the framework. `Github contracts`_.
**pex**
  This branch is based on the ``contracts`` branch and includes additional unit tests designed to be instrumented by Pex_, a parameterized unit test generator. `Github pex`_.
**itu**
  The tracking branch, this branch tracks the state of development by the original maintainers since the release of v1.1.0. As there has been no known development, this branch has only the initial commit, from which this project is based. `Github itu`_.
**doc**
  The documentation branch, this branch is an independent branch which contains documentation for the C5 library, including the C5 Book. The source code of the book is unavailable, so as development continues, the book may fall out of sync with the library, though this hasn't happened yet. `Github doc`_.

__ `Microsoft Code Contracts`_

Source
======
Source code for the C5 library can be obtained from the `github repository`__.

__ `C5 Github`_

Development
===========
The library's source is organized into source, test, and example directories. The main source of the library is included in the ``C5/`` directory. The tests are split between the ``nunit`` and ``C5.Tests/`` directories. The ``nunit/`` directory contains legacy tests from the original ITU release, while the ``C5.Tests/`` will contain all new tests. As test coverage from ``C5.Tests/`` increases, the legacy tests will be removed. This is part of a greater initiative to improve the maintainability of the library.

The ``UserGuideExamples/`` directory includes several source files demonstrating how to use the C5 library to various ends, many of which are examples in the `C5 Book`_.

Questions/Help
==============
The `#c5`__ channel has been set up on FreeNode for any C5-related questions.

__ irc://irc.freenode.net/#c5

.. [#] Common Language Infrastructure, defined by `ECMA-335`_.
.. _`ITU C5`: http://www.itu.dk/research/c5/
.. _`Microsoft Code Contracts`: http://research.microsoft.com/projects/contracts
.. _Pex: http://research.microsoft.com/projects/pex
.. _`C5 Github`: http://github.com/neoeinstein/c5
.. _`Github master`: http://github.com/neoeinstein/c5/tree/master
.. _`Github contracts`: http://github.com/neoeinstein/c5/tree/contracts
.. _`Github pex`: http://github.com/neoeinstein/c5/tree/pex
.. _`Github itu`: http://github.com/neoeinstein/c5/tree/itu
.. _`Github doc`: http://github.com/neoeinstein/c5/tree/doc
.. _`C5 Book`: http://github.com/neoeinstein/c5/raw/doc/C5%20book.pdf
.. _`ECMA-335`: http://www.ecma-international.org/publications/standards/Ecma-335.htm
